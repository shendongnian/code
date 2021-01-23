      #region donloadfiles
                        if (b = file.Contains(story))
                        {
                            try
                            {
                                logger.Info("calling xml creation Method");
                                baseMeta(story, XML);
                                logger.Info("XML created");
                            }
                            catch (Exception ex)
                            { logger.Error(ex.Message); throw; }
    
                            logger.Info("calling Download Method");
                            Download(file, story, xml, program);
                            logger.Info("Download Method processed successfully");
                        }
    else return "no matches found";
                            #endregion
