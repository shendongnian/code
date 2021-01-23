    int i = 0;
    public void next(){
        if (i+1 < this.LabelTextList.Count())
           lblText.text = this.LabelTextList[++i];
    }
    public void prev(){
        if (i-1 >= 0)
            lblText.text = this.LabelTextList[--i];
    }
