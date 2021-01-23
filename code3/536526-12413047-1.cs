    string xmlString =
                    @"<AnchoredXml xmlns='urn:schema:Microsoft.Rtc.Management.ScopeFramework.2008' SchemaWriteVersion='1'>
      <Key ScopeClass='Global'>
        <SchemaId Namespace='urn:schema:Microsoft.Rtc.Management.Settings.ServiceAssignment.2008' ElementName='ServiceAssignments' />
        <AuthorityId Class='Host' InstanceId='00000000-0000-0000-0000-000000000000' />
      </Key>
      <Dictionary Count='1'>
        <Item>
          <Key />
          <Value Signature='2ffb6b0d-0239-4016-b08b-40520d1687ff'>
            <ServiceAssignments xmlns='urn:schema:Microsoft.Rtc.Management.Settings.ServiceAssignment.2008'>
              <ServiceAssignment TagId='659550892'>
                <Component Name='Registrar'>
                  <ServiceId xmlns='urn:schema:Microsoft.Rtc.Management.Deploy.Topology.2008' SiteId='1' RoleName='Registrar' Instance='1' />
                </Component>
                <Component Name='PresenceFocus'>
                  <ServiceId xmlns='urn:schema:Microsoft.Rtc.Management.Deploy.Topology.2008' SiteId='1' RoleName='UserServices' Instance='1' />
                </Component>
              </ServiceAssignment>
              <ServiceAssignment TagId='911048693'>
                <Component Name='Registrar'>
                  <ServiceId xmlns='urn:schema:Microsoft.Rtc.Management.Deploy.Topology.2008' SiteId='1' RoleName='Registrar' Instance='2' />
                </Component>
                <Component Name='PresenceFocus'>
                  <ServiceId xmlns='urn:schema:Microsoft.Rtc.Management.Deploy.Topology.2008' SiteId='1' RoleName='UserServices' Instance='2' />
                </Component>
              </ServiceAssignment>
            </ServiceAssignments>
          </Value>
        </Item>
      </Dictionary>
    </AnchoredXml>";
    
    var doc = XDocument.Parse(xmlString);       
    var TagIds = doc.Descendants()
                    .Elements()
                    .Where(e => 
                                e.HasAttributes && 
                                e.Name.LocalName.Equals("ServiceAssignment") && 
                                e.Attribute("TagId") != null)
                    .Select(e => e.Attribute("TagId").Value);
