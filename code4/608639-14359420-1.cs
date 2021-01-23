    <%    
        string[] data = { "ABC", "DEF", "GHI", "XYZ" };
        int i = 1;
        
        try
        {
            foreach(string item in data)
            {
                Response.Write("<br/><div style=\"font-size:small\">");
                Response.Write(String.Format("Element {0} = {1}", i, item));
                Response.Write("</div>");
                i++;
            }
            Response.Write("<br/>");
        }
        catch (Exception) 
        { 
            Response.Write("Error");
        }
    %>
