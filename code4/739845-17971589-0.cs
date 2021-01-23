        [HttpGet]
        public virtual ActionResult LocationEditor(int index)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Locations[{0}]", index);
            return PartialView(@"EditorTemplateExplicitPathAsOnlyViewNameAintGonnaWork.cshtml");
        }
