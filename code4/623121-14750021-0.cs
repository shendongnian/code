    void OnClick(){
      GameObject panel2  = GameObject.Find("Panel2");
      NGUITools.SetActive(panel2,true);       
      GameObject panel1  = GameObject.Find("Panel1");         
      NGUITools.SetActive(panel1,false);
    }
