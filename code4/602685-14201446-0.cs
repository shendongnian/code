    //Recupera valores dos indices para o tipo de documento
                    List<Gedi.Models.OperacoesModel.imports> valuesList = new List<Gedi.Models.OperacoesModel.imports>();
                    var valuesListObj = from a in context.sistema_Documentos
                                        join b in context.sistema_Indexacao on a.id equals b.idDocumento
                                        join c in context.sistema_Indexes on b.idIndice equals c.id
                                        where a.ativo == 1
                                        select new
                                        {
                                            id = a.id,
                                            values = c.idName + ":" + b.valor
                                        };
                    var çist = (from x in valuesListObj.AsEnumerable()
                                select new Gedi.Models.OperacoesModel.imports
                                {
                                    id = x.id,
                                    values = x.values
                                }).ToList();
                    var importList = çist.GroupBy(p => p.id).Select(g => new Gedi.Models.OperacoesModel.imports
                                                                            {
                                                                                id = g.Key,
                                                                                values = string.Join(",", g.Select(p => p.values))
                                                                            }).ToList();
