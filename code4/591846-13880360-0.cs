    var xml = @"
    <Root>
       <Policy id='832cbfc6-a451-4d77-a995-4ceb9d3bbe01' username ='DCassidy'>     
          <Title>Test 1</Title>    
      </Policy>
      <Policy id='832cbfc6-a451-4d77-a995-4ceb9d3bbe02' userName ='DCassidy'>
        <Title>Test 2</Title>
     </Policy>
    </Root>
    ";
    var xElement = XElement.Parse(xml);
    var subset = xElement.Elements("Policy").SelectMany(e => e.Elements());
