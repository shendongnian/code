    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            int f = 0;
            int g = 0;
            int h = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;
            int n = 0;
            int o = 0;
            int p = 0;
            int q = 0;
            int r = 0;
            int s = 0;
            int t = 0;
            int u = 0;
            int v = 0;
            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;
            int A = 0;
            int B = 0;
            int C = 0;
            int D = 0;
            int E = 0;
            int F = 0;
            int G = 0;
            int H = 0;
            int I = 0;
            int J = 0;
            int K = 0;
            int L = 0;
            int M = 0;
            int N = 0;
            int O = 0;
            int P = 0;
            int Q = 0;
            int R = 0;
            int S = 0;
            int T = 0;
            int U = 0;
            int V = 0;
            int W = 0;
            int X = 0;
            int Y = 0;
            int Z = 0;
            int readChar = 0;
            int word = 0;
            int lower = 0;
            int upper = 0;
            string inputString ="";
            char ch = ' ';
            string findString = "";
            int space = 0;
            int startingPoint = 0;
            int findStringCount = 0;
            
            Console.Write("Please enter a string: ");
            
            do{
                readChar = Console.Read();
                ch = Convert.ToChar(readChar);
                if (ch.Equals(' '))
                {
                    space++;
                }
                else if (Char.IsLower(ch))
                {
                    lower++;
                    if (ch.Equals('a')) 
                    {
                        a++;
                    }
                    else if (ch.Equals('b')) 
                    {
                        b++;
                    }
                    else if (ch.Equals('c')) 
                    {
                        c++;
                    }
                    else if (ch.Equals('d')) 
                    {
                        d++;
                    }
                    else if (ch.Equals('e')) 
                    {
                        e++;
                    }
                    else if (ch.Equals('f')) 
                    {
                        f++;
                    }
                    else if (ch.Equals('g')) 
                    {
                        g++;
                    }
                    else if (ch.Equals('h')) 
                    {
                        h++;
                    }
                    else if (ch.Equals('i')) 
                    {
                        i++;
                    }
                    else if (ch.Equals('j')) 
                    {
                        j++;
                    }
                    else if (ch.Equals('k')) 
                    {
                        k++;
                    }
                   else if (ch.Equals('l')) 
                    {
                        l++;
                    }
                    else if (ch.Equals('m')) 
                    {
                        m++;
                    }
                    else if (ch.Equals('n')) 
                    {
                        n++;
                    }
                    else if (ch.Equals('o')) 
                    {
                        o++;
                    }
                    else if (ch.Equals('p')) 
                    {
                        p++;
                    }
                    else if (ch.Equals('q')) 
                    {
                        q++;
                    }
                    else if (ch.Equals('r')) 
                    {
                        r++;
                    }
                    else if (ch.Equals('s')) 
                    {
                        s++;
                    }
                    else if (ch.Equals('t')) 
                    {
                        t++;
                    }
                    else if (ch.Equals('u')) 
                    {
                        u++;
                    }
                    else if (ch.Equals('v')) 
                    {
                        v++;
                    }
                    else if (ch.Equals('w')) 
                    {
                        w++;
                    }
                    else if (ch.Equals('x')) 
                    {
                        x++;
                    }
                    else if (ch.Equals('y')) 
                    {
                        y++;
                    }
                    else if (ch.Equals('z')) 
                    {
                        z++;
                    }
                }
                else if (Char.IsUpper(ch))
                {
                    upper++;
                    if (ch.Equals('A')) 
                    {
                        A++;
                    }
                    else if (ch.Equals('B')) 
                    {
                        B++;
                    }
                    else if (ch.Equals('C')) 
                    {
                        C++;
                    }
                    else if (ch.Equals('D')) 
                    {
                        D++;
                    }
                    else if (ch.Equals('E')) 
                    {
                       E++;
                    }
                    else if (ch.Equals('F')) 
                    {
                        F++;
                    }
                    else if (ch.Equals('G')) 
                    {
                       G++;
                    }
                    else if (ch.Equals('H')) 
                    {
                        H++;
                    }
                    else if (ch.Equals('I')) 
                    {
                       I++;
                    }
                    else if (ch.Equals('J')) 
                    {
                        J++;
                    }
                    else if (ch.Equals('K')) 
                    {
                        K++;
                    }
                    else if (ch.Equals('L')) 
                    {
                        L++;
                    }
                    else if (ch.Equals('M')) 
                    {
                       M++;
                    }
                    else if (ch.Equals('N')) 
                    {
                        N++;
                    }
                    else if (ch.Equals('O')) 
                    {
                        O++;
                    }
                    else if (ch.Equals('P')) 
                    {
                       P++;
                    }
                    else if (ch.Equals('Q')) 
                    {
                        Q++;
                    }
                    else if (ch.Equals('R')) 
                    {
                        R++;
                    }
                    else if (ch.Equals('S')) 
                    {
                       S++;
                    }
                    else if (ch.Equals('T')) 
                    {
                        T++;
                    }
                    else if (ch.Equals('U')) 
                    {
                        U++;
                    }
                    else if (ch.Equals('V')) 
                    {
                        V++;
                    }
                    else if (ch.Equals('W')) 
                    {
                        W++;
                    }
                    else if (ch.Equals('X')) 
                    {
                        X++;
                    }
                    else if (ch.Equals('Y')) 
                    {
                        Y++;
                    }
                    else if (ch.Equals('Z')) 
                    {
                        Z++;
                    }
                }
                if (((ch.Equals(' ') && (!inputString.EndsWith(" ")))||(ch.Equals('\r') && (!inputString.EndsWith(" "))))&&(inputString!=""))
                {
                    word++;
                }
               
                inputString = inputString + ch;
            } while (ch != '\r');
            Console.ReadLine();
            Console.WriteLine("Report on {0}",inputString);
            Console.WriteLine("# of spaces {0}",space);
            Console.WriteLine("# of lower {0}", lower);
            Console.WriteLine("# of upper {0}", upper);
            Console.WriteLine("# of word {0}", word);
            Console.WriteLine("UPPERCASE");
            if (A >= 1)
            {
                Console.WriteLine("A = {0}",A);
            }
            if (B >= 1)
            {
                Console.WriteLine("B = {0}",B);
            }
            if (C >= 1)
            {
                Console.WriteLine("C = {0}", C);
            }
            if (D >= 1)
            {
                Console.WriteLine("D = {0}", D);
            }
            if (E >= 1)
            {
                Console.WriteLine("E = {0}", E);
            }
            if (F >= 1)
            {
                Console.WriteLine("F = {0}", F);
            } if (G >= 1)
            {
                Console.WriteLine("G = {0}", G);
            }
            if (H >= 1)
            {
                Console.WriteLine("H = {0}", H);
            }
            if (I >= 1)
            {
                Console.WriteLine("I = {0}", I);
            }
            if (J >= 1)
            {
                Console.WriteLine("J = {0}", J);
            }
            if (K >= 1)
            {
                Console.WriteLine("K = {0}", K);
            }
            if (L >= 1)
            {
                Console.WriteLine("L = {0}", L);
            }
            if (M >= 1)
            {
                Console.WriteLine("M = {0}", M);
            }
           if (N >= 1)
            {
                Console.WriteLine("N = {0}",N);
            }
            if (O >= 1)
            {
                Console.WriteLine("O = {0}",O);
            }
            if (P >= 1)
            {
                Console.WriteLine("P = {0}",P);
            }
            if (Q >= 1)
            {
                Console.WriteLine("Q = {0}",Q);
            }
            if (R >= 1)
            {
                Console.WriteLine("R = {0}",R);
            }
            if (S >= 1)
            {
                Console.WriteLine("S = {0}",S);
            }
            if (T >= 1)
            {
                Console.WriteLine("T = {0}",T);
            }
            if (U >= 1)
            {
                Console.WriteLine("U = {0}",U);
            }
            if (V >= 1)
            {
                Console.WriteLine("V = {0}",V);
            }
            if (W >= 1)
            {
                Console.WriteLine("W = {0}",W);
            }
            if (X >= 1)
            {
                Console.WriteLine("X = {0}",X);
            }
            if (Y >= 1)
            {
                Console.WriteLine("Y = {0}",Y);
            }
            if (Z >= 1)
            {
                Console.WriteLine("Z = {0}",Z);
            }
            Console.WriteLine("LOWERCASE");
            if (a >= 1)
            {
                Console.WriteLine("a = {0}", a);
            }
            if (b >= 1)
            {
                Console.WriteLine("b = {0}", b);
            }
            if (c >= 1)
            {
                Console.WriteLine("c = {0}", c);
            }
            if (d >= 1)
            {
                Console.WriteLine("d = {0}", d);
            }
            if (e >= 1)
            {
                Console.WriteLine("e = {0}", e);
            }
            if (f >= 1)
            {
                Console.WriteLine("f = {0}", f);
            } if (g >= 1)
            {
                Console.WriteLine("g = {0}", g);
            }
            if (h >= 1)
            {
                Console.WriteLine("h = {0}", h);
            }
            if (i >= 1)
            {
                Console.WriteLine("i = {0}", i);
            }
            if (j >= 1)
            {
                Console.WriteLine("j = {0}", j);
            }
            if (k >= 1)
            {
                Console.WriteLine("k = {0}", k);
            }
            if (l >= 1)
            {
                Console.WriteLine("l = {0}", l);
            }
            if (m >= 1)
            {
                Console.WriteLine("m = {0}", m);
            }
            if (n >= 1)
            {
                Console.WriteLine("n = {0}", n);
            }
            if (o >= 1)
            {
                Console.WriteLine("o = {0}", o);
            }
            if (p >= 1)
            {
                Console.WriteLine("p = {0}", p);
            }
            if (q >= 1)
            {
                Console.WriteLine("q = {0}", q);
            }
            if (r >= 1)
            {
                Console.WriteLine("r = {0}", r);
            }
            if (s >= 1)
            {
                Console.WriteLine("s = {0}", s);
            }
            if (t >= 1)
            {
                Console.WriteLine("t = {0}", t);
            }
            if (u >= 1)
            {
                Console.WriteLine("u = {0}", u);
            }
            if (v >= 1)
            {
                Console.WriteLine("v = {0}", v);
            }
            if (w >= 1)
            {
                Console.WriteLine("w = {0}", w);
            }
            if (x >= 1)
            {
                Console.WriteLine("x = {0}", x);
            }
            if (y >= 1)
            {
                Console.WriteLine("y = {0}", y);
            }
            if (z >= 1)
            {
                Console.WriteLine("z = {0}", z);
            }
            Console.WriteLine();
            Console.Write("Please enter a substring ");
            findString = Console.ReadLine();
            if (findString.Length <= inputString.Length)
            {
                do
                {
                    if (inputString.IndexOf(findString, startingPoint) != -1)
                    {
                        findStringCount++;
                        startingPoint = inputString.IndexOf(findString, startingPoint) + findString.Length;
                    }
                } while (inputString.IndexOf(findString, startingPoint) != -1);
            }
            else
            {
                Console.WriteLine("Substring is too long!");
            }
            Console.WriteLine("The number of times that {0} is found in the text is {1}", findString, findStringCount);
            Console.ReadLine();
            
        }
    }
}
