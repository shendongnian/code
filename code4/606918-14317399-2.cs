            var array = new[] { new { PlaneName = "" } };
            array = null;
            var expected = new[]
                               {
                                   new
                                       {
                                           PilotName = "Higgins",
                                           Planes = array
                                       },
                                   new
                                       {
                                           PilotName = "Higgins",
                                           Planes = new[]
                                                        {
                                                            new { PlaneName = "B-52" },
                                                            new { PlaneName = "F-14" }
                                                        }
                                       }
                               };
