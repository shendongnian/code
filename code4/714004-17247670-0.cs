    var contents = _contentsRepository.GetAll()	            
                                      .Where(a => 
                                      {
                                          return a.ContentTypeId == 99 ||
                                          (a.SubjectId == subjectId && 
                                          a.ContentTypeId == contentTypeId && 
                                          a.ContentStatusId == contentStatusId)
                                      }
