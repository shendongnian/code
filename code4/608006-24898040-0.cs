    public interface IApplicantBusiness
    {
        List<Template.Model.ApplicantView> GetAllApplicants();
        void InsertApplicant(Template.Model.ApplicantView applicant);
}
}
