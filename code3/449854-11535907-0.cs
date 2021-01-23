            string code = textBox1.Text;
            string sBarcode = string.Empty;
            sBarcode = IsValidGtin(code);
            lblBarCode.Text = sBarcode;
        }
        public static string IsValidGtin(string code)
        {
            //if (code != (new Regex("[^0-9]")).Replace(code, ""))
            //{
            //    // is not numeric
            //    return false;
            //}
            // pad with zeros to lengthen to 14 digits
            switch (code.Length)
            {
                case 2:
                    code = code + "000000000";
                    break;
                case 3:
                    code = code + "00000000";
                    break;
                case 4:
                    code = code + "0000000";
                    break;
                case 5:
                    code = code + "000000";
                    break;
                case 6:
                    code = code + "00000";
                    break;
                case 7:
                    code = code + "0000";
                    break;
                case 8:
                    code = code + "000";
                    break;
                case 9:
                    code = code + "00";
                    break;
                case 10:
                    code = code + "0";
                    break;
                case 11:
                    break;
                case 12:
                    code = code.Substring(0, 11);
                    break;
                //default:
                // wrong number of digits
                //  return false;
            }
            // calculate check digit
            int[] a = new int[12];
            a[0] = int.Parse(code[0].ToString()) * 3;
            a[1] = int.Parse(code[1].ToString());
            a[2] = int.Parse(code[2].ToString()) * 3;
            a[3] = int.Parse(code[3].ToString());
            a[4] = int.Parse(code[4].ToString()) * 3;
            a[5] = int.Parse(code[5].ToString());
            a[6] = int.Parse(code[6].ToString()) * 3;
            a[7] = int.Parse(code[7].ToString());
            a[8] = int.Parse(code[8].ToString()) * 3;
            a[9] = int.Parse(code[9].ToString());
            a[10] = int.Parse(code[10].ToString()) * 3;
            //a[11] = int.Parse(code[11].ToString());
            //a[12] = int.Parse(code[12].ToString()) * 3;
            int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10];
            string check = Convert.ToString((10 - (sum % 10)));
            // evaluate check digit
            // int last = int.Parse(code[13].ToString());
            // return check == last;
            code = code + check;
            return code;
        }
