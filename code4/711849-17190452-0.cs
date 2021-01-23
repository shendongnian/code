    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [AttributeUsage(AttributeTargets.Property)]
            public class MyInfoAttribute : Attribute
            {
            }
    
            public class TListNF
            {
                public TListNF(int iProductID = 0, string sProductName = "", string sProductIDNum = "", string sProductDesc = "", string sColor = "", bool bMake = false, bool bCustom = false)
                {
                    this.iProductID = iProductID;
                    this.sProductName = sProductName;
                    this.sProductIDNum = sProductIDNum;
                    this.sProductDesc = sProductDesc;
                    this.sColor = sColor;
                    this.bMake = bMake;
                    this.bCustom = bCustom;
                }
    
                [MyInfo]
                public int iProductID { get; set; }
                [MyInfo]
                public string sProductName { get; set; }
                [MyInfo]
                public string sProductIDNum { get; set; }
                [MyInfo]
                public string sProductDesc { get; set; }
                [MyInfo]
                public string sColor { get; set; }
                [MyInfo]
                public bool bMake { get; set; }
                [MyInfo]
                public bool bCustom { get; set; }
    
                protected List<TListNF> ItemList = new List<TListNF>();
    
                public IEnumerable<string> GetItemInfo()
                {
                    yield return iProductID.ToString();
                    yield return sProductName;
                    yield return sProductIDNum;
                    yield return sProductDesc;
                    yield return sColor;
                    yield return bMake.ToString();
                    yield return bCustom.ToString();
                }
            }
    
            class TProduct : TListNF
            {
                public void FillData(int iProductID, string sProductName, string sProductIDNum, string sProductDesc, string sColor, bool bMake, bool bCustom)
                {
                    ItemList.Add(new TListNF(iProductID, sProductName, sProductIDNum, sProductDesc, sColor, bMake, bCustom));
                }
    
                public void PrintData()
                {
                    foreach (TListNF item in ItemList)
                    {
                        foreach (string info in item.GetItemInfo())
                            Console.WriteLine(info);
                    }
                }
    
                public void PrintDataReflection()
                {
                    Type type = typeof(MyInfoAttribute);
    
                    foreach (TListNF item in ItemList)
                    {
                        foreach (PropertyInfo proInfo in item.GetType().GetProperties().Where(p => p.GetCustomAttributes(type, true).Length > 0))
                        {
                            Console.WriteLine(proInfo.GetGetMethod().Invoke(item, null).ToString());
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                var test = new TProduct();
    
                test.FillData(1, "Apple", "4857", "A tasty apple.", "Green", false, true);
    
                test.PrintData();
                test.PrintDataReflection();
    
                Console.ReadKey();
            }
        }
    }
