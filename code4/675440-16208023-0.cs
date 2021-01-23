    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace JsonRecursiveDescent
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json =
                @"[
                    {
                        ""X"":
                        {
                            ""Title"":""foo"",
                            ""xxxx"":""xxxx""
                        }
                    },
                    {
                        ""Y"":
                        {
                            ""ZZ"":
                            {
                                ""Title"":""bar"",
                                ""xxxx"":""xxxx""
                            }
                        }
                    }
                ]";
    
                JToken node = JToken.Parse(json);
    
                WalkNode(node, n =>
                {
                    JToken token = n["Title"];
                    if (token != null && token.Type == JTokenType.String)
                    {
                        string title = token.Value<string>();
                        Console.WriteLine(title);
                    }
                });
            }
    
            static void WalkNode(JToken node, Action<JObject> action)
            {
                if (node.Type == JTokenType.Object)
                {
                    action((JObject)node);
    
                    foreach (JProperty child in node.Children<JProperty>())
                    {
                        WalkNode(child.Value, action);
                    }
                }
                else if (node.Type == JTokenType.Array)
                {
                    foreach (JToken child in node.Children())
                    {
                        WalkNode(child, action);
                    }
                }
            }
        
        }
    }
