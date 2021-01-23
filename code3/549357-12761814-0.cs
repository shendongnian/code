        using System;
        using System.IO;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Double val;
                    val = LoadDoubleValue();
                    Console.WriteLine("Previous Value was: " + val);
                    Console.Write("Please enter Value for next startup: ");
                    string input = Console.ReadLine();
                    if (Double.TryParse(input, out val))
                    {
                        SaveDoubleValue(val);
                    }
                }
                static Double LoadDoubleValue()
                {
                    Double ret = 0;
                    if(File.Exists("save.dat")){
                        if (!Double.TryParse(File.ReadAllLines("save.dat")[0], out ret))
                        {
                            ret = 15;
                        }
                    }else{
                        ret = 15;
                    }
                    return ret;
                }
                static void SaveDoubleValue(Double val)
                {
                    File.WriteAllLines("save.dat", new string[] { val.ToString() });
                }
            }
        }
