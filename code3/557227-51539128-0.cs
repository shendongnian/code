    **1. Why Swagger4Wcf**
    ----------------------
    
    •Manually writing yaml description for swagger and maintain it especially WCF services are boring. 
    •There is a nuget package called Swagger4WCF that automatically generates yaml description for swagger 2.0 for each interface matching attributes used by WCF (ServiceContract/OperationContract/WebGet/WebInvoke).
    
    2. How Swagger Works in the Background
    --------------------------------------
    
    Swagger4WCF uses NuPack post build pattern to trigger at build time.
    https://www.codeproject.com/Tips/1190360/How-to-setup-a-managed-postbuild-without-scripting
    3.At build time, it will detect assemblies present in output directory, open them with mono.cecil (to reflect assemblies) to generate expected yaml description for swagger 2.0.
    Swagger4WCF detects **WebGet/WebInvoke** to provide Verb/Method in serialization style in yaml.
    
    Steps to implement Swagger in your application:-
    
    1. Install SwaggerWcf package
    
    2. Configure WCF routes
    We have to add the route in the Application_Start method inside Global.asax
    
         protected void Application_Start(object sender, EventArgs e)
                {
                    RouteTable.Routes.Add(new ServiceRoute("v1/rest", new WebServiceHostFactory(), typeof(BookStore)));
                    RouteTable.Routes.Add(new ServiceRoute("api-docs", new WebServiceHostFactory(), typeof(SwaggerWcfEndpoint)));
                }
    
    
    
    Note: Edit Web.config and add the following (if it doesn't exist yet) inside the system.serviceModel block
    
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
    
    3. Configure WCF response auto types (optional)
    We have to add the following to Web.config. This will allow the WCF service to accept requests and send replies based on the Content-Type headers.
    
    
    
    
    
    
          <behavior name="webHttpBehavior">
                  <webHttp defaultOutgoingResponseFormat="Json" automaticFormatSelectionEnabled="true"/>
                </behavior>
              </endpointBehaviors>
              <serviceBehaviors>
                <behavior>
                  <!-- To avoid disclosing metadata information, set the values below to false before deployment -->
                  <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
                  <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
                  <serviceDebug includeExceptionDetailInFaults="false"/>
                </behavior>
    
    
    
    4. Decorate WCF services interfaces
    For each method, we have to configure the WebInvoke or WebGet attribute, and add a SwaggerWcfPath attribute.
    
    
    
     [SwaggerWcfPath("Get book", "Retrieve a book from the store using its id")]
            [WebGet(UriTemplate = "/books/{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
            [OperationContract]
            Book ReadBook(string id);
    
    
    
    
    5. Decorate WCF services class
    
    •   Add the SwaggerWcf and AspNetCompatibilityRequirements attributes to the class providing the base path for the service.
    •   For each method, add the SwaggerWcfTag to categorize the method and theSwaggerWcfResponse for each possible response from the service.
    
    
    
    [SwaggerWcfTag("Books")]
    [SwaggerWcfResponse(HttpStatusCode.OK, "Book found, value in the response body")]
    [SwaggerWcfResponse(HttpStatusCode.NoContent, "No books", true)]
    public Book[] ReadBooks()
    {
    }
    
    
    
    6. Decorate data types used in WCF services
    
    
    
     [DataContract]
        [Description("Book with title, first publish date, author and language")]
        [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
        public class Book
        {
            [DataMember]
            [Description("Book ID")]
            public string Id { get; set; }
    
            [DataMember]
            [Description("Book Title")]
            public string Title { get; set; }
    
            [DataMember]
            [Description("Book First Publish Date")]
            public int FirstPublished { get; set; }
    
            [DataMember]
            [Description("Book Author")]
            public Author Author { get; set; }
    
            [DataMember]
            [Description("Book Language")]
            public Language Language { get; set; }
        }
    
     That's it wcf for Swagger implemented.
    Please free if you face any issue.
    
    Thanks,
    Abhi
