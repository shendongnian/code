    public class sum
    {
        public void checkinsum(int productid, float sum)
        {
            //Since the sum is a float it will check the difference 
            //into unroundedsum table in the database 
            int intsum = (int)sum;
            float tempfloat = sum - intsum;
            //Check this remaining float into the database under unaccounted
            // dbobject("unroundedsum",productid,tempfloat);                
            //Now call the integer checksum with the integer value
        }
        public void checkinsum(int productid, int sum)
        {
            //Checks in price in the price table
            //dbobject("price",productid,sum);
            int temp_int = sum;
        }
    }
