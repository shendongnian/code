    private void MyLoadMethod(string firstConceptCKI)
    {
      Queue<string> pendingItems = new Queue<string>();
      pendingItems.Enqueue(firstConceptCKI);
      while(pendingItems.Count != 0)
      {
        string conceptCKI = pendingItems.Dequeue();
        // make some script calls to DB, so that moTargetConceptList2 will have Concept-Relations for the current node. 
        // when this is zero, it means its a leaf. 
        int numberofKids = moTargetConceptList2.ConceptReltns.Count();
        for (int i = 1; i <= numberofKids; i++)
        {
            oUCMRConceptReltn = moTargetConceptList2.ConceptReltns.get_ItemByIndex(i, false);
    
            //Get the concept linked to the relation concept
            if (oUCMRConceptReltn.SourceCKI == sConceptCKI)
            {
                oConcept = moTargetConceptList2.ItemByKeyConceptCKI(oUCMRConceptReltn.TargetCKI, false);
            }
            else
            {
                oConcept = moTargetConceptList2.ItemByKeyConceptCKI(oUCMRConceptReltn.SourceCKI, false);
            }
    
            //builder.AppendLine("\t" + oConcept.PrimaryCTerm.SourceString);
            Debug.WriteLine(oConcept.PrimaryCTerm.SourceString);
    
            pendingItems.Enque(oConcept.ConceptCKI);
        }
      }
    }
