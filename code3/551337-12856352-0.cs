    foreach (var programme in programmes)
                {
                    routes.MapRoute("ProgrammeArea" + " " + programme.Code,
                                    programme.Url + "/{action}/{id}",
                                    new { controller = "PaymentDetails", action = "Index", id = programme.Id }
                        );
                }
