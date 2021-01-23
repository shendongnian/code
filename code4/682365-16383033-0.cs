                List<Product> _prod_list = new List<Product>();
                _prod_list = ProductDataFactory.GetProductListByVendor(vendor_name);
                if (_prod_list.Count() > 0)
                {
                    using (StreamReader reader = new StreamReader(df_text_filename))
                    {
                        using (StreamWriter writer = new StreamWriter(df_text_filename + "_temp"))
                        {
                            while ((product = reader.ReadLine()) != null)
                            {
                                if (product != _aff_svc.DFHeaderProd)
                                {
                                    df_product = _product_factory.GetProductData(_vsi, product);
                                }
                                if (_prod_list.Find(o => o.SKU == df_product.SKU) != null)
                                {
                                    continue;
                                }
                                writer.WriteLine(product);
                            }
                            writer.Close();
                        }
                        reader.Close();
                    }
                    System.IO.File.Delete(df_text_filename);
                    System.IO.File.Move(df_text_filename + "_temp", df_text_filename);
                }
