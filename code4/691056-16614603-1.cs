    function MyObjectDefinition()
    {
        this.publicField = 0;
        var that = this;
        var privateField;
    
        this.MyObjectDefinition = function(parameter)
        {
            privateField = parameter;   
            SomethingThatWantsA.CallBack(PrivateMethod);
        }
    
        this.PublicMethod = function()
        {
            privateField--;
            // or that.publicField--; if you are paranoid/like consistency
            this.publicField--; 
        }
    
        function PrivateMethod()
        {
            privateField++;
            that.publicField++;
        }
    }
    
    var instance = new MyObjectDefinition();   
