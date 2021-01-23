    private void button1_Click(object sender, EventArgs e)
            {
                var ok = "OK" + (char)0;
                var ascii = Encoding.ASCII;
    
                var bin = ascii.GetBytes( ok );
    
                var sb = new StringBuilder();
                unsafe
                {
    
                    fixed (byte* p = bin)
                    {
                        byte b = 1;
                        var i = 0;
                        while (b != 0)
                        {
                            b = p[i];
    
                            if (b != 0) sb.Append( ascii.GetString( new[] {b} ) );
                            i++;
                        }
                    }
                }
                Console.WriteLine(sb);
            }
