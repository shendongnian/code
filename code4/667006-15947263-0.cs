    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace SimpleMath
    {
    public class AEM : IOperation
    {
        public static int[] Calculate(int i, int j)
        {
            int[] ints = new int[] { i, j };
            Array.Sort(ints);
            List<int> powers = new List<int>();
            int power = 1;
            int first = ints[0];
            int iReturn = 0;
            int iReturnP = 0;
            int iReturnN = 0;
            do
            {
                powers.Add(power);
                power = new Multiply().Calculate(power, 2);
            } while (power <= first);
            iReturnP += first;
            while (first > 0)
            {
                int next = powers.LastOrDefault(x => x <= first);
                first -= next;
                int powertotal = new Multiply().Calculate(next, i);
                iReturnN += next;
                iReturn += powertotal;
            }
            return new int[]{iReturnP, iReturnN, iReturn};
            }
    }
    }
