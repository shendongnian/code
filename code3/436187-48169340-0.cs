    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class palindrome
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number:");
            string panstring = Console.ReadLine();
            Palindrome(panstring);
            Console.ReadKey();
        }
         static int index = 0;
         public static void Palindrome(string strexcluding)
        {
            try
            {
                string reversecounter = string.Empty;
                for (int i = strexcluding.Length - 1; i >= 0; i--)
                {
                    if (strexcluding[i].ToString() != null)
                        reversecounter += strexcluding[i].ToString();
                }
                if (reversecounter == strexcluding)
                {
                    Console.WriteLine("Palindrome Number: " + strexcluding);
                }
                else
                {
                    Sum(strexcluding);
                }
            }
             catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
        public static void Sum(string stringnumber)
        {
            try
            {
                index++;
                string number1 = stringnumber;
                string number2 = stringnumber;
                string[] array = new string[number1.Length];
                string obtained = string.Empty;
                string sreverse = null;
                Console.WriteLine(index + ".step : " + number1 + "+" + number2);
                for (int i = 0; i < number1.Length; i++)
                {
                    int temp1 = Convert.ToInt32(number1[number2.Length - i - 1].ToString());
                    int temp2 = Convert.ToInt32(number2[number2.Length - i - 1].ToString());
                    if (temp1 + temp2 >= 10)
                    {
                        if (number1.Length - 1 == number1.Length - 1 - i)
                        {
                            array[i] = ((temp1 + temp2) - 10).ToString();
                            obtained = "one";
                        }
                        else if (number1.Length - 1 == i)
                        {
                            if (obtained == "one")
                            {
                                array[i] = (temp1 + temp2 + 1).ToString();
                            }
                            else
                            {
                                array[i] = (temp1 + temp2).ToString();
                            }
                        }
                        else
                        {
                            if (obtained == "one")
                            {
                                array[i] = ((temp1 + temp2 + 1) - 10).ToString();
                            }
                            else
                            {
                                array[i] = ((temp1 + temp2) - 10).ToString();
                                obtained = "one";
                            }
                        }
                    }
                    else
                    {
                        if (obtained == "one")
                            array[i] = (temp1 + temp2 + 1).ToString();
                        else
                            array[i] = (temp1 + temp2).ToString();
                        obtained = "Zero";
                    }
                }
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] != null)
                        sreverse += array[i].ToString();
                }
                Palindrome(sreverse);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
