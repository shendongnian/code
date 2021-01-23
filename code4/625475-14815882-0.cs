    @functions{
    
    
    MvcHtmlString CreateTree(MvcApplication2.Models.Category  category)
    {
        var swriter  = new StringWriter();
        var writer = new System.Xml.XmlTextWriter(swriter);
    
        CreateTree(category, writer);
    
        writer.Close();
    
        return new MvcHtmlString(swriter.ToString());
    }
    
    void CreateTree(MvcApplication2.Models.Category  category, System.Xml.XmlWriter outputWriter)
    {
        if (category.Parent != null)
        {
            CreateTree(category.Parent, outputWriter);
        }
        
        // bubble up after recursion
        outputWriter.WriteStartElement("ul");
        outputWriter.WriteElementString("li", category.Title);
        outputWriter.WriteStartElement("li");
    }  
    
    }
    
        <div>
    
        @CreateTree(ViewBag.Category)
    
            
        </div>
