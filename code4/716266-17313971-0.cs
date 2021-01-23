    public class MyXslFileLoader
    {
    	public void Load()
    	{
    		Load(AppDomain.CurrentDomain.BaseDirectory + "\XML Transformationen\Transformation_01.xslt");
    	}
    	
    	public void Load(string path)
    	{
    		Xsl = GetXSLFromFile(path);
    	}
    }
