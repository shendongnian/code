    // Copyright 2012 Henrik Feldt
    //  
    // Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
    // this file except in compliance with the License. You may obtain a copy of the 
    // License at 
    // 
    //     http://www.apache.org/licenses/LICENSE-2.0 
    // 
    // Unless required by applicable law or agreed to in writing, software distributed 
    // under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
    // CONDITIONS OF ANY KIND, either express or implied. See the License for the 
    // specific language governing permissions and limitations under the License.
    
    using System;
    using System.Threading;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Magnum.Extensions;
    using Magnum.TestFramework;
    using MassTransit;
    using NUnit.Framework;
    
    namespace ConsoleApplication11
    {
    	[TestFixture]
    	public class TestSendCommandReceiveEvent
    	{
    		ManualResetEventSlim _received = new ManualResetEventSlim(false);
    		IWindsorContainer _container;
    
    		[Given]
    		public void installation_of_infrastructure_objects()
    		{
    			_container = new WindsorContainer();
    			_container.Register(
    				Component.For<IServiceBus>()
    					.UsingFactoryMethod(() => ServiceBusFactory.New(x =>
    						{
    							x.ReceiveFrom("loopback://localhost/mt_client");
    							x.Subscribe(conf =>
    								{
    									conf.Consumer(() => new MyEventConsumer(_received));
    									conf.Consumer(() => new MyCmdConsumer());
    								});
    						})));
    
    			when();
    		}
    
    		public void when()
    		{
    			var localBus = _container.Resolve<IServiceBus>();
    			// wait for startup
    			localBus.Endpoint.InboundTransport.Receive(c1 => c2 => { }, 1.Milliseconds()); 
    			
    			localBus.Publish(new DoSomething());
    		}
    
    		[Then]
    		public void corresponding_event_should_be_received_by_consumer()
    		{
    			_received.Wait(5000).ShouldBeTrue();
    		}
    	}
    
    	[Serializable]
    	public class DoSomething
    	{
    	}
    
    	[Serializable]
    	public class SomethingDone
    	{
    	}
    
    	public class MyEventConsumer : Consumes<SomethingDone>.All
    	{
    		readonly ManualResetEventSlim _received;
    
    		public MyEventConsumer(ManualResetEventSlim received)
    		{
    			_received = received;
    		}
    
    		public void Consume(SomethingDone message)
    		{
    			_received.Set();
    		}
    	}
    
    	public class MyCmdConsumer : Consumes<DoSomething>.Context
    	{
    		public void Consume(IConsumeContext<DoSomething> ctx)
    		{
    			Console.WriteLine("consumed cmd");
    			ctx.Bus.Publish(new SomethingDone());
    		}
    	}
    }
