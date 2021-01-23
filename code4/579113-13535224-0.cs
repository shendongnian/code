    class Program
    {
        static void Main(string[] args)
        {
            string[] uptonineteen = {"Zero","One","Two","Three","Four",
            "Five","Six","Seven","Eight","Nine","Ten",
            "Eleven","Twelve","Thirteen","Fourteen","Fifteen",
            "Sixteen","Seventeen","Eighteen","Nineteen"};
            string[] ten = {"", "","Twenty","Thirty","Forty","Fifty",
            "Sixty","Seventy","Eighty","Ninety",};
            Console.WriteLine(" ---------------");
            int i = int.Parse(Console.ReadLine());
            if (i < 20)
            {
                Console.WriteLine(uptonineteen[i]);
            }
            else if (i < 100)
            {
                Console.WriteLine(((((i % 100) / 10) > 1) ? ten[((i % 100) / 10)] + ((i % 10) > 0 ? " " + uptonineteen[(i % 10)] : "") : " and " + uptonineteen[i % 100]));
            }
            else if (i <= 999)
            {
                object lenthree = uptonineteen[(i % 1000) / 100] + " hundred " + ((((i % 100) / 10) > 1) ? ten[((i % 100) / 10)] + ((i % 10) > 0 ? " " + uptonineteen[(i % 10)] : "") : " and " + uptonineteen[i % 100]);
                Console.WriteLine(lenthree);
            } 
            Console.ReadLine();
        }
    }
