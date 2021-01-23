    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace simplearraything
    {
    class myarrayitem
    {
        public int uid;
        public int pid;
        public int keyword_uid;
        public int product_uid;
        public int amount;
        public int in_title;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //array('uid' => '23','pid' => '2','keyword_uid' => '23','product_uid' => '1','amount' => '12','in_title' => '0'),
            string Original = File.ReadAllText("array.txt").Replace("array('uid' => '", "").Replace(
                "','pid' => '", "/").Replace("','keyword_uid' => '", "/").Replace("','product_uid' => '", "/").Replace(
                "','amount' => '", "/").Replace("','in_title' => '", "/").Replace("'),", "").Replace("\r","");
            string[] lines = Original.Split('\n');
            List<myarrayitem> mystuff = new List<myarrayitem>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] thisitem = lines[i].Split('/');
                myarrayitem item = new myarrayitem();
                item.uid = int.Parse(thisitem[0]);
                item.pid = int.Parse(thisitem[1]);
                item.keyword_uid = int.Parse(thisitem[2]);
                item.product_uid = int.Parse(thisitem[3]);
                item.amount = int.Parse(thisitem[4]);
                item.in_title = int.Parse(thisitem[5]);
                mystuff.Add(item);
            }
            // Now, output it to prove accuracy:
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine("UID:" + mystuff[i].uid.ToString() + "/PID:" + mystuff[i].pid.ToString() + "/KEYWORD_UID:" + mystuff[i].keyword_uid.ToString() +
                    "/PRODUCT_UID:" + mystuff[i].product_uid.ToString() + "/amount:" + mystuff[i].amount.ToString() + "/in_title:" + mystuff[i].in_title.ToString());
            }
            Console.Read();
        }
    }
    }
