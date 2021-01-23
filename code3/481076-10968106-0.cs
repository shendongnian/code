    public class Program
    {
        string buff="0";
        public static void Main(string[] args)
        {
            
            string ok = "OK";
    
            SerialPort p = new SerialPort("COM28");
            p.DataReceived += new SerialDataReceivedEventHandler(p_DataReceived);
            p.Open();
            string line = "1";
            p.Write("AT" + "\r");
            Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
            p.Write("AT+CMGF=1"+ "\r" );
            Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
            do
            {
                p.Write("AT+CMGL=\"REC UNREAD\" " + "\r");
                Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
                if (buff.Contains(ok))
                    Console.WriteLine("Everything is OK");
                else
                    Console.WriteLine("NOK");
                line = Console.ReadLine();
            } while (line != "quit");
            p.Close();
        }
    
        public static void p_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = (sender as SerialPort).ReadExisting();
            buff += s;
            Console.WriteLine(s);
        }
    } 
