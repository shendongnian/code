    using System.Drawing;
    namespace FontNameCheckApplication
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Font TimesNewRomanByPSName = new Font("TimesNewRomanPSMT", 16f);
                Console.WriteLine("TimesNewRomanPSMT = {0}", TimesNewRomanByPSName.Name);
                Font TimesNewRomanByName = new Font("Times New Roman", 16f);
                Console.WriteLine("Times New Roman = {0}", TimesNewRomanByName.Name);
                Font ArialByPSName = new Font("ArialMT", 16f);
                Console.WriteLine("ArialMT = {0}", ArialByPSName.Name);
                Font ArialByName = new Font("Arial", 16f);
                Console.WriteLine("Arial = {0}", ArialByName.Name);
                Font GulimByEnglishName = new Font("Gulim", 16f);
                Console.WriteLine("Gulim = {0}", GulimByEnglishName.Name);
                Font GulimByKoreanName = new Font("굴림", 16f);
                Console.WriteLine("굴림 = {0}", GulimByKoreanName.Name);
                Console.ReadKey();
            }
        }
    }
