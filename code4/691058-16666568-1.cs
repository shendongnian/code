    function MyObjectDefinition(parameter)
    {
        this.publicField = 0;
        var that = this;
        var privateField;
        this.PublicMethod = function()
        {
            privateField--;
            this.publicField--;
        }
        if(parameter !== undefined)
        {
            privateField = parameter;
            SomethingThatWantsACallBack(PrivateMethod);
            SomethingThatWantsACallBack(this.PublicMethod);
        }
        function PrivateMethod()
        {
            privateField++;  
            that.publicField++;
        }
    }
