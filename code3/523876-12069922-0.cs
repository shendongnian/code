    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Microsoft.WindowsAzure.ServiceRuntime;
    namespace pageengine.clients
    {
        public class RepositoryBase<T> : IDisposable
        {
            #region Channel
            protected String roleName;
            protected String serviceName;
            protected String endpointName;
            protected String protocol = @"http";
            protected EndpointAddress _endpointAddress;
            protected BasicHttpBinding httpBinding;
            protected NetTcpBinding tcpBinding;
            protected IChannelFactory channelFactory;
            protected T client;
            protected virtual AddressHeader[] addressHeaders
            {
                get
                {
                    return null;
                }
            }
            protected virtual EndpointAddress endpointAddress
            {
                get
                {
                    if (_endpointAddress == null)
                    {
                        var endpoints = RoleEnvironment.Roles[roleName].Instances.Select(i => i.InstanceEndpoints[endpointName]).ToArray();
                        var endpointIP = endpoints.FirstOrDefault().IPEndpoint;
                        if(addressHeaders != null)
                        {
                            _endpointAddress = new EndpointAddress(new Uri(String.Format("{1}://{0}/{2}", endpointIP, protocol, serviceName)), addressHeaders);
                        }
                        else
                        {
                            _endpointAddress = new EndpointAddress(String.Format("{1}://{0}/{2}", endpointIP, protocol, serviceName));
                        }
                    
                    }
                    return _endpointAddress;
                }
            }
            protected virtual Binding binding
            {
                get
                {
                    switch (protocol)
                    {
                        case "tcp.ip":
                            if (tcpBinding == null) tcpBinding = new NetTcpBinding();
                            return tcpBinding;
                        default:
                            //http
                            if (httpBinding == null) httpBinding = new BasicHttpBinding();
                            return httpBinding;
                    }
                }
            }
            public virtual T Client
            {
                get
                {
                    if (this.client == null)
                    {
                        this.channelFactory = new ChannelFactory<T>(binding, endpointAddress);
                        this.client = ((ChannelFactory<T>)channelFactory).CreateChannel();
                        ((IContextChannel)client).OperationTimeout = TimeSpan.FromMinutes(2);
                        var scope = new OperationContextScope(((IContextChannel)client));
                        addCustomMessageHeaders(scope);
                    }
                    return this.client; 
                }
            }
            protected virtual void addCustomMessageHeaders(OperationContextScope operationContextScope)
            {
                // Overidden
            }
            #endregion
            #region CTOR
            public RepositoryBase()
            {
            }
            #endregion
            #region IDisposable Members
            public virtual void Dispose()
            {
                if (client != null)
                {
                    try
                    {
                        ((ICommunicationObject)client).Close();
                    }
                    catch
                    {
                        try
                        {
                            ((ICommunicationObject)client).Abort();
                        }
                        catch { } // Die quietly.
                    }
                }
                if (channelFactory != null)
                {
                    try
                    {
                        channelFactory.Close();
                    }
                    catch
                    {
                        try
                        {
                            channelFactory.Abort();
                        }
                        catch { } // Die quietly.
                    }
                    channelFactory = null;
                }
                _endpointAddress = null;
                httpBinding = null;
                tcpBinding = null;
            }
            #endregion
        }
    }
