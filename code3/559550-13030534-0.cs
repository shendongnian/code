    if (assessment.UnmappedCaseStudiesCount == 0) {
        TempData[TempDataKeys.ErrorMessage.GetEnumName()] = 
            "This assessment (\"{0}\") has no case studies!".FormatWith(assessment.Name);
        actionRes = RedirectToAction("Index", "Events");
        return null;
    }
 
