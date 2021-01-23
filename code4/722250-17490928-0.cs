    public class ConverNumber
	{
		public string InputString { get; private set; }
		public double Number { get; private set; }
		public void ConvertNumber(string inputString, out double number)
		{
			if (!Double.TryParse(inputString, out number))
			{
				Console.WriteLine("Вы не ввели значение!");
			}
		}
	}
