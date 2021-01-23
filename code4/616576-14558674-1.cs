    public void Replace(Essay x)
        {
            x.Name = x.Name.Replace('0', ((char)240));
            x.Name = x.Name.Replace('1', ((char)241));
            x.Name = x.Name.Replace('2', ((char)242));
            x.Name = x.Name.Replace('3', ((char)243));
            x.Name = x.Name.Replace('4', ((char)244));
            x.Name = x.Name.Replace('5', ((char)245));
            x.Name = x.Name.Replace('6', ((char)246));
            x.Name = x.Name.Replace('7', ((char)247));
            x.Name = x.Name.Replace('8', ((char)248));
            x.Name = x.Name.Replace('9', ((char)249));
        }
        public void Revert(Essay x)
        {
            x.Name = x.Name.Replace(((char)240), '0');
            x.Name = x.Name.Replace(((char)241), '1');
            x.Name = x.Name.Replace(((char)242), '2');
            x.Name = x.Name.Replace(((char)243), '3');
            x.Name = x.Name.Replace(((char)244), '4');
            x.Name = x.Name.Replace(((char)245), '5');
            x.Name = x.Name.Replace(((char)246), '6');
            x.Name = x.Name.Replace(((char)247), '7');
            x.Name = x.Name.Replace(((char)248), '8');
            x.Name = x.Name.Replace(((char)249), '9');
            
        }
