    private static T GetAnonType<T>(T type, object obj)
    		{
    			return (T)obj;
    		}
    Object obj= l1.Items.GetItemAt(0);
    var info = GetAnonType(new { AA = aa++, Description = descriptions[k], Shop = names[k + 2], Price = price},obj);
