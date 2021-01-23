    private static void Generatelabels(FPGAViewModel currentItem)
    {
      for(i = 0; i < 0x40 / 8; i++)
      {
           reg = (i * 8);
           currentItem.RegisterLabel[i] 
               = String("Reg 0x") + String::toHexString(reg);
          currentItem.IsRegisterItemsVisible = true;
       }
    }
   
