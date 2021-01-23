     var data=[
        
                            { id: 1, color: 'yellow' },
                            { id: 2, color: 'blue' },
                            { id: 3, color: 'red' }
                            ]; //parameter
            var para={};
            para.datav=data;   //datav from View
            
              
            $.ajax({
                        traditional: true,
                        url: "/Conroller/MethodTest",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        data:para,
                        success: function (data) {
                            $scope.DisplayError(data.requestStatus);
                        }
                    });
        
    In MVC
    
    
    public class Thing
        {
            public int id { get; set; }
            public string color { get; set; }
        }
        
        public JsonResult MethodTest(IEnumerable<Thing> datav)
            {
           //now  datav is having all your values
          }
