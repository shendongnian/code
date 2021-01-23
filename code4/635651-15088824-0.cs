        class Details : MainDetails
        {
            string Attr3 { get; set; }
            string Attr4 { get; set; }
            string Attr5 { get; set; }
            public override string this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 3:
                            return Attr3;
                        case 4:
                            return Attr4;
                        case 5:
                            return Attr5;
                    }
                    return base[index];
                }
            }
        }
        class MainDetails
        {
            string Attr1 { get; set; }
            string Attr2 { get; set; }
            public virtual string this[int index] 
            {
                get
                {
                    switch (index)
                    {
                        case 1:
                            return Attr1;
                        case 2:
                            return Attr2;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }
