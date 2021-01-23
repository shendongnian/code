      for (int i = 0; i < fm1.lstCart.Items.Count; i++) 
            {
                if (fm1.lstCart.Items[i].ToString().Contains(productName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
       return false;
