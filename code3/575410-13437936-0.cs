    PdfConcatenate whole = new PdfConcatenate(...);
    foreach (var ca in caseList)
    {
        byte[] part = null;
        if (ca.CaseType == "CTA")
        {
            part = GenerateEvaluationCAT_PDF(learnerID, ca.ID);
        }
        else if (ca.CaseType == "CTAH")
        {
            part = GenerateEvaluationCATH_PDF(learnerID, ca.ID);
        }
        else
        {
            part = ???;
        }
        PdfReader partReader = new PdfReader(part);
        whole.addPages(partReader);
        partReader.close();
    }
