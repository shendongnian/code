     using System;  
     using System.Windows.Forms;  
     using ServiceStack.Plugins.ProtoBuf;  
     using System.Runtime.Serialization;  
     using ServiceStack.ServiceClient.Web;  
 
    namespace client  
 
    {  
 
     public partial class Form1 : Form  
 
     {  
 
    private ServiceClientBase _client;  
 
    private const string Url = "http://localhost/servicestack.demo/servicestack/";  
 
    public Form1()  
 
    {  
 
      InitializeComponent();  
 
    }  
 
    private void Button1Click(object sender, EventArgs e)  
 
    {  
 
      this._client =  
 
        new ProtoBufServiceClient(Url);  
 
      var response = _client.Send<HelloResponse>("GET","/hello",new Hello {Name = "ProtoBuf"});  
 
      label1.Text = response.Result;  
 
     }  
 
     }  
 
    [DataContract]  
 
    public class Hello  
 
    {  
 
    [DataMember(Order = 1)]  
 
    public string Name { get; set; }  
 
    }  
 
    [DataContract]  
 
    public class HelloResponse  
 
     {  
 
    [DataMember(Order = 1)]  
 
    public string Result { get; set; }  
 
     } 
 
 
 
     }
