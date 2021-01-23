    <CheckBox Name="check1" IsChecked="{Binding Path=myViewModelProperty1}" />
    <CheckBox Name="check2" IsChecked="{Binding Path=myViewModelProperty2}" />
    <CheckBox Name="check3" IsChecked="{Binding Path=myViewModelProperty3}" />
    <CheckBox Name="check4" IsChecked="{Binding Path=myViewModelProperty4}" />
        public Boolean myViewModelProperty1
        {
            get 
            { 
                return this.b1;  
            }
            set 
            { 
                this.b1  =value;
                this.EvaluateMyEnum();
            }
        }
        public Boolean myViewModelProperty2
        {
            get 
            { 
                return this.b2;  
            }
            set 
            { 
                this.b2  =value;
                this.EvaluateMyEnum();
            }
        }
        public Boolean myViewModelProperty3
        {
            get 
            { 
                return this.b2;  
            }
            set 
            { 
                this.b2  =value;
                this.EvaluateMyEnum();
            }
        }
        public Boolean myViewModelProperty4
        {
            get 
            { 
                return this.b4;  
            }
            set 
            { 
                this.b4  =value;
                this.EvaluateMyEnum();
            }
        }
        void EvaluateMyEnum()
        {
            this.MyViewModelEnum = ......;
            this.RaisePropertyChanged<MyEnum>(() => this.myViewModelEnum);
        }
