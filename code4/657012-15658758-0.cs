    IQueryable<CandidateGeographiesAttributes> 
    obj_Candidate_Geographies_Attributes_List = 
    (from c in DBEntity.Candidates 
        join p in DBEntity.vw_Candidate_AttributesNew.ToList() on c.CandidateId
        equals  p.CandidateId 
        join q in obj_Candidate_Geographies_List on c.CandidateId 
        equals q.CandidateId 
        select new CandidateGeographiesAttributes
        { 
	        CandidateId = c.CandidateId, 
    	    FirstName = q.FirstName, 
    	    LastName = q.LastName, 
    	    GeographyId = q.GeographyId, 
    	    GeographyName = q.GeographyName, 
    	    SkillId = p.SkillId, 
    	    SkillName = p.SkillName, 
    	    CreatedOn = c.CreatedOn, 
    	    ModifiedOn = c.ModifiedOn 
        }
    );
    //Predefined Model 
    public class CandidateGeographiesAttributes 
    { 
	public int CandidateId { get; set; } 
	public string FirstName { get; set; }
	public string LastName { get; set; } 
	public int GeographyId { get; set; } 
	public string GeographyName { get; set; } 
	public int SkillId { get; set; } 
	public string SkillName { get; set; } 
	public DateTime CreatedOn { get; set; } 
	public DateTime ModifiedOn { get; set; } 
    }
