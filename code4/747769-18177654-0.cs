    public class Model
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedUserID { get; set; }
        
        public virtual Dto AsDto()
        {
            return FillDto(new Dto());
        }
    
        protected Dto FillDto(Dto dto)
        {
            dto.CreatedDate = this.CreatedDate;
            dto.CreatedUserID = this.CreatedUserID; //etc..
            return dto;
        }
    }
    
    
    public class CompanyModel : Model
    {
        public string CompanyName { get; set; }
    
        public override Dto AsDto()
        {
            return FillDto(new CompanyDto());
        }
    
        protected CompanyDto FillDto(CompanyDto dto)
        {
            base.FillDto(dto);
            dto.CompanyName = this.CompanyName;
            return dto;
        }
    }
    
    public class PeopleModel : CompanyModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public override Dto AsDto()
        {
            return FillDto(new PeopleDto());
        }
    
        protected PeopleDto FillDto(PeopleDto dto)
        {
            base.FillDto(dto);
            dto.FirstName = this.FirstName;
            dto.LastName = this.LastName; //etc...
            return dto;
        }
    }
