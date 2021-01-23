    var machines = xmlDoc.Descendants("Machine");
    foreach(var machine in machines)
    {
        System.Diagnostics.Debug.WriteLine("Machine: {0}", machine.Element("MachineName"));
        
        foreach(var feature in machine.Descendants("Feature").Select(f => new { 
                  name= f.Element("FeatureName").Value, 
                  enabled = f.Element("FeatureEnabled").Value 
                }))
        {
            System.Diagnostics.Debug.WriteLine("  Feature: Name={0}, Enabled={1}", feature.name, feature.enabled);
        }
    }
