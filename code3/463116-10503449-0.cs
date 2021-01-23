    if(Request.HttpMethod == "GET") {
        Debug.WriteLine("this is just a request for the page"):
    }
    else if(Request.HttpMethod == "POST") {
        Debug.WriteLine("processing the form");
        //rest of code...
    }
    else {
        //some HTTP action that doesn't matter
    }
