    // parse the document (this is your doc but I've made the xml parseable)
    var doc = XDocument.Parse(@"<chars>
            <character name=""MyChar1"">
            <skill1 type=""attack"" damage=""30"">
                description of skill1
                <name>Skill name</name>
                <class1 type=""The Class Type""></class1>
                <class2 type=""The Class Type 2""></class2>
            </skill1>
    		</character>
        <character name=""MyChar2"">
            <skill1 type=""attack"" damage=""30""></skill1>
        </character>
    </chars>");
    
    // Access a skill1 type(attribute) where the name(attribute) is "MyChar" 
    // this is pretty easy with LINQ. We first get all descendant nodes of type "character"
    var skillWhereNameIsMyChar1 = doc.Descendants("character")
        // then take the single one with an attribute named "value"
    	.Single(ch => ch.Attribute("name") != null && ch.Attribute("name").Value == "MyChar1")
        // and take that element's child element of type skill1 
    	.Element("skill1");
    Console.WriteLine(skillWhereNameIsMyChar1);
    
    // 2. Access the description of skill1 where name(att) is "MyChar1"
    // this is tricky because the description text is just floating among other tags
    // if description were wrapped in <description></description>, this would be simply
    // var description = skillWhereNameIsMyChar1.Element("description").Value;
    // here's the hacky way I found to get it in the current xml:
    // first get the full value (inner text) of the skill node (includes "Skill Name")
    var fullValue = skillWhereNameIsMyChar1.Value;
    // then get the concatenated full values of all child nodes (= "Skill Name")
    var innerValues = string.Join("", skillWhereNameIsMyChar1.Elements().Select(e => e.Value));
    // get the description by dropping off the trailing characters that are actually inner values
    var description = fullValue.Substring(0, fullValue.Length - innerValues.Length);
    Console.WriteLine(description);
