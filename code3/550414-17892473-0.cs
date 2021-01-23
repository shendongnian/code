    //Called from with a jQuery ready() in a simple html page
    var getNewPerson = function ()
    {
    var NewPerson       = new Object();
    NewPerson.PersonID  = "0";
    NewPerson.FirstName = $("#FirstName").val();
    NewPerson.LastName  = $("#LastName").val();
    NewPerson.Address   = $("#Address").val();
    NewPerson.City      = $("#City").val();
    NewPerson.State     = $("#State").val();
    NewPerson.Zip       = $("#Zip").val();
    var arrObj;
    var str = "";
    var webMethod = "http://someserver.com/admin/DataHandler.ashx";
    $.ajax({
    cache: false,
    url: webMethod,
    type: "POST",
    dataType: "json",
     /* for hashtable or .net web service -  data: "{\"NewPerson\":" + JSON.stringify(NewPerson) + "}", */
    data: JSON.stringify(NewPerson), 
    contentType: "application/json; charset=utf-8"
    }
    )
    .done( function(){}... code here ...etc)
    //Valid JSON object format: {"PersonID":"1","FirstName":"Rick","LastName":"Wright","Address":"4520 No Such address Ave.","City":"Riverside","State":"CA","Zip":"92503"}
    //And here is a sample class on the C# side in the .ashx handler page.
    public class NewPerson
        {
            public int PersonID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
        } //  EOC Person
             
