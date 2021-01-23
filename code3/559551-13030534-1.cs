    if (AssessmentHasNoCaseStudies(assessment, out actionRes)) {
        return null;
    }
    ...
    private bool AssessmentHasNoCaseStudies(Assessment assessment, out ActionResult actionRes)
    {
        actionRes = (assessment.UnmappedCaseStudiesCount == 0)
            ? RedirectToAction("Index", "Events")
            : null;
        if (actionRes == null)
        {
            return false;
        }
        TempData[TempDataKeys.ErrorMessage.GetEnumName()] = 
            "This assessment (\"{0}\") has no case studies!".FormatWith(assessment.Name);
        return true;
    }
