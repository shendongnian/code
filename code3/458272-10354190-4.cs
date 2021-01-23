            var bob = new {
                name = "test"
                ,
                orders = new [] {
                    new  { itemNo = 1, description = "desc"}
                    ,new  { itemNo = 2, description = "desc2"}
                   
                }
                ,test = new  {
                        a = new {
                            b = new {
                                something = "testing"
                                ,someOtherThing = new {
                                    aProperty="1"
                                    ,another="2"
                                    ,theThird=new{
                                        bob="quiteDeepNesting"
                                    }
                                }
                            }
                        }
                    }
            };
            return Json(bob, JsonRequestBehavior.AllowGet);
