    **ImageButton btn = ((ImageButton)sender).CommandArgument;** 
      switch (btn.ToString()) 
      { 
            case "ThisBtnClick": 
                Debug.Print("--" + btn.CommandArgument.ToString()); 
                break; 
            case "ThatBtnClick": 
                break; 
       } 
} 
