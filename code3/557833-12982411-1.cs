        public int Matricnumber
        {
            get { return matricnumber; }
            set 
            {
               if (value < MinMatric || value > MaxMatric)
                 throw new ArgumentOutOfRangeException("Matricnumber"); 
               matricnumber = value; 
            }
        }
