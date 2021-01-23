    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    public class MVCClient
        {
            public delegate void DataDelegateArray<T>(T[] objects);
            public delegate void DataDelegate<U>(U obj);
            
        #region Communication Functions
            public void DoPostMessage<T>(string queryURL, T item, ProcessPOSTResult<T> callback)
            {
                DoPostMessage<T, T>(queryURL, item, callback);
            }
    
            public void DoPostMessage<TPost, TReply>(string queryURL, TPost item, ProcessPOSTResult<TReply> callback)
            {
    #if SILVERLIGHT
                Uri uri = new Uri(queryURL, UriKind.Absolute);
    
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.BeginGetRequestStream(result =>
                    {
                        var req = (HttpWebRequest)result.AsyncState;
                        var stream = req.EndGetRequestStream(result);
    
                        if (stream != null)
                        {
                            var data = new
                            {
                                name = item
                            };
    
    
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TPost));
                            serializer.WriteObject(stream, item);
                            stream.Close();
                        }
    
                        req.BeginGetResponse((requestResult) =>
                        {
                            var req2 = (HttpWebRequest)requestResult.AsyncState;
                            var response = req2.EndGetResponse(requestResult);
                            var responseStream = response.GetResponseStream();
                            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TReply));
                            TReply responseItem = (TReply)serializer.ReadObject(responseStream);
    
                            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                            {
                                callback(responseItem);
                            });
    
                        }, req);
                    }, request);
    
    #endif
            }
    
            public void DoGetMessage<T>(string queryURL, DataDelegateArray<T> callback)
            {
                DoGetMessage<T[]>(queryURL, result => callback(result));
            }
    
            public void DoGetMessage<T>(string queryURL, DataDelegate<T> callback)
            {
    #if SILVERLIGHT
                Uri uri = new Uri(queryURL, UriKind.Absolute);
    
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.Accept = "text/json";
                request.BeginGetResponse((result) =>
                {
                    var response = request.EndGetResponse(result);
                    var stream = response.GetResponseStream();
    
                    if (stream != null)
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        T data = (T)serializer.ReadObject(stream);
                        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            callback(data);
                        });
                    }
                    else
                        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            callback(default(T));
                        });
                }, null);
    #endif
            }
            #endregion
        }
