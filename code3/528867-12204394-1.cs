    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    
    namespace TestProject1
    {
        [TestClass]
        public class Test
        {
            [TestMethod]
            public void TestSteps()
            {   
                var random = new Random();
                for (int i = 0; i < 20000; i++)
                {
                    int numberOfEvents = random.Next(1,1000);
                    var generator = new RandomTimeStepGenerator(numberOfEvents);
                    var stopwatch = new Stopwatch(); 
                    stopwatch.Start();
                    var steps = generator.MillisecondDeltas;
                    Assert.AreEqual(numberOfEvents, steps.Count);
                    var sum = generator.MillisecondDeltas.Sum();
                    Assert.AreEqual(1000.0,sum,0.1);
                    Assert.IsTrue(stopwatch.ElapsedMilliseconds<10);
                }
                
            }        
        }
    
        public class RandomTimeStepGenerator
        {
            private readonly int _numberOfEvents;
            const int timeResolution = 10000;
    
            public RandomTimeStepGenerator(int numberOfEvents)
            {
                _numberOfEvents = numberOfEvents;
            }
    
            public int NumberOfEvents
            {
                get { return _numberOfEvents; }
            }
    
            public List<double> MillisecondDeltas
            {
                get
                {
                    var last=0;
                    var result = new List<double>();
                    var random = new Random();
                    
                    for (var i = 0; i < timeResolution && result.Count < _numberOfEvents; i++)
                    {
                        var remainingEvents = _numberOfEvents - result.Count;
                        var remainingTime = timeResolution - i;
                        if(remainingEvents==1) // make sure the last event fires on the second
                        {
                            result.Add((timeResolution - last) / 10.0);
                            last = i;  
                        }
                        else if (remainingTime <= remainingEvents) // hurry up and fire you lazy !!! your going to run out of time 
                        {
                            result.Add(0.1);
                        }
                        else
                        {
                            double probability = remainingEvents / (double)remainingTime;
                            int next = random.Next(0,timeResolution);                        
                            if ((next*probability) > _numberOfEvents)
                            {
                                result.Add((i - last)/10.0);
                                last = i;
                            }
                        }                   
                    }                 
                    return result;
                }
            }
        }    
    }
