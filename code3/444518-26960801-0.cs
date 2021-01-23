    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    
    namespace pof
    {
        class eva
        {
            public string po;
            public string answer;
            Stack i = new Stack();
            public void e()
            {
                int a, b, ans;
                for (int j = 0; j < po.Length; j++)
                {
                    String c = po.Substring(j, 1);
                    if (c.Equals ("*"))
                    {
                        String sa = (String)i.Pop();
                        String sb = (String)i.Pop();
                        a = Convert.ToInt32(sb); 
                        b = Convert.ToInt32(sa);
                        ans = a * b;
                        i.Push(ans.ToString());
    
                    }
                    else if (c.Equals("/"))
                    {
                        String sa = (String)i.Pop();
                        String sb = (String)i.Pop();
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);
                        ans = a / b;
                        i.Push(ans.ToString());
                    }
                    else if (c.Equals("+"))
                    {
                        String sa = (String)i.Pop();
                        String sb = (String)i.Pop();
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);
                        ans = a + b;
                        i.Push(ans.ToString());
    
                    }
                    else if (c.Equals("-"))
                    {
                        String sa = (String)i.Pop();
                        String sb = (String)i.Pop();
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);
                        ans = a - b;
                        i.Push(ans.ToString());
    
                    }
                    else
                    {
                        i.Push(po.Substring(j, 1));
                    }
                }
              answer=(String)i.Pop();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                eva e1 = new eva();
                Console.WriteLine("enter any postfix expression");
                e1.po = Console.ReadLine();
                e1.e();
                Console.WriteLine("\n\t\tpostfix evaluation:  " + e1.answer);
                Console.ReadKey();
            }
        }
    }
