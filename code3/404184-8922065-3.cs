List< string > urls = new List< string >
urls.add("www.google.com");
urls.add("www.ggg.com");
foreach(var url in urls)
{
     //cast string to HttpResponse will need here...
     if( GetHeaders(url).ToString() == "400" )
         MessageBox.Show(url + " status code is 400");
}
</pre>
