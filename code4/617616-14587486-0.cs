    byte[] content = File.ReadAllBytes(myFileName);
    
    var groups = (from character in content 
                  group character by character).ToDictionary(g => g.Key, g => (float)g.Count() / content.Length);
    float[] stats = (from character in Enumerable.Range(0, 255)
                     select groups[character]).ToArray();
