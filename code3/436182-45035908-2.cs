     private void CheckIfPalindrome(string str) 
            {
                //place string in array of chars
                char[] array = str.ToCharArray(); 
                int length = array.Length -1 ;
                Boolean palindrome =true;
                for (int i = 0; i <= length; i++)//go through the array
                {
                    if (array[i] != array[length])//compare if the char in the same positions are the same eg "tattarrattat" will compare array[0]=t with array[11] =t if are not the same stop the for loop
                    {
                        MessageBox.Show("not");
                        palindrome = false;
                        break;
                        
                    }
                    else //if they are the same make length smaller by one and do the same 
                    {                   
                      length--;
                    }
    
                }
                if (palindrome) MessageBox.Show("Palindrome"); 
                       
            }
