    using System; 
    using System.Runtime.InteropServices; 
    using ComTypes = System.Runtime.InteropServices.ComTypes;
    
    public class ComHelper 
    {
        public static string GetValue(object comObj, string name)
        {
            if (comObj == null)
                return String.Empty;
    
            if (!Marshal.IsComObject(comObj))
                //The specified object is not a COM object 
                return String.Empty;
    
            IDispatch dispatch = comObj as IDispatch;
            if (dispatch == null)
                //The specified COM object doesn't support getting type information 
                return String.Empty; 
    
            try
            {
                int language_id = 0;
                int DISPATCH_METHOD = 0x1;
                int DISPATCH_PROPERTYGET = 0x2;
    
                int[] displayIDs = new int[1];
                Guid empty = Guid.Empty;
                string[] names = new string[] { name };
                dispatch.GetIDsOfNames(ref empty, names, names.Length, language_id, displayIDs);
                System.Runtime.InteropServices.ComTypes.DISPPARAMS dspp = new System.Runtime.InteropServices.ComTypes.DISPPARAMS();
                System.Runtime.InteropServices.ComTypes.EXCEPINFO ei = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
                IntPtr[] arg_err = new IntPtr[10];
                object result;
                if (1 == displayIDs.Length)
                {
                    dispatch.Invoke(displayIDs[0], ref empty, language_id, (ushort)(DISPATCH_METHOD | DISPATCH_PROPERTYGET), ref dspp, out result, ref ei, arg_err);
                    return result.ToString();
                }
                return String.Empty;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
            }
        }
    }
