    string xml = "<Exceptions>
      <Exception Name='Address'>
        <Error id='Line1' message='Address Line 1 is required'/>
        <Error id='Line1Length' message='Address Line 1 must be in-between 1 and 50'/>
        <Error id='Line2Length' message='Address Line 2 must be in-between 1 and 50'/>
      </Exception>
    </Exceptions>";
    
    var document = XDocument.Load(xml);
    var messages = document.Descendants("Exception").Attributes("message").Select(a => a.Value);
