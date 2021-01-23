    private void addToScript(ScriptModel model, List<int> ids)
        {
            Script script = scriptRepository.GetScriptWithItems(model.ScriptId);
            List<History> historyItems = historyRespository.History.Where(h => ids.Contains(h.Id)).ToList();
            
            ScriptItem lastScriptItem = script.Items.OrderByDescending(item => item.SortIndex).FirstOrDefault();
            int topSortIndex = lastScriptItem == null ? 0 : lastScriptItem.SortIndex;
            if (script != null)
            {
                Mapper.CreateMap<History, ScriptItem>();
                List<ScriptItem> Parents = new List<ScriptItem>();
                List<History> SourceParents = historyItems
                    .Where(h => historyItems.Any(h2 => h2.ParentId == h.Id)).ToList();
                SourceParents.Each(h =>
                {
                    ScriptItem parent = new ScriptItem();
                    Mapper.Map(h, parent);
                    parent.Script = script;
                    Parents.Add(parent);
                });
                historyItems.Except(SourceParents).Each(h =>
                {
                    ScriptItem child = new ScriptItem();
                    Mapper.Map(h, child);
                    child.Script = script;
                    if (child.ParentId.HasValue)
                        child.Parent = Parents.SingleOrDefault(p => p.Id == child.ParentId);
                    script.Items.Add(child);
                });
                //Todo: Get sortIndex "sorted" out
                
                scriptRepository.SaveScript(script);
            }
        }
